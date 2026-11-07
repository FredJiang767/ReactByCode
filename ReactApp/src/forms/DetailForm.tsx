import { useState, type SubmitEvent } from 'react'
import { useQuery } from '@tanstack/react-query'
import { getJson, postJson } from '@/api/request'
import type { FormValues, PageSection, SaveResult } from './PageConfiguration'

export function DetailForm({ section }: { section: PageSection }) {
  const form = section.form!
  const id = new URLSearchParams(window.location.search).get('id')
  const query = useQuery({
    queryKey: ['form', section.key, id],
    queryFn: () => getJson<FormValues>(id ? section.source + '?id=' + encodeURIComponent(id) : section.source),
  })
  const [edited, setEdited] = useState<FormValues | null>(null)
  const [errors, setErrors] = useState<Record<string, string>>({})
  const [message, setMessage] = useState('')
  const values = edited ?? query.data

  if (query.isLoading) return <p role="status">Loading...</p>
  if (query.isError || !values) return <p role="alert">{query.error?.message ?? 'The record was not found.'}</p>

  async function submit(event: SubmitEvent<HTMLFormElement>) {
    event.preventDefault()
    setMessage('')
    try {
      const result = await postJson<SaveResult>(section.saveSource!, values)
      setErrors(result.errors)
      if (result.id !== null) {
        setEdited({ ...values, customerID: result.id })
        window.history.replaceState(null, '', window.location.pathname + '?id=' + result.id)
        setMessage('Saved.')
      }
    } catch (error) {
      setMessage((error as Error).message)
    }
  }

  return (
    <section className="card">
      <h2>{id ? 'Edit' : 'New'}</h2>
      <form className="criteria" onSubmit={submit}>
        {form.fields.map((field) => (
          <label key={field.key}>
            <span>{field.label}{field.required ? ' *' : ''}</span>
            <input type={field.type} value={String(values[field.key] ?? '')} onChange={(e) => setEdited({ ...values, [field.key]: e.target.value })} />
            {errors[field.key] && <span className="error" role="alert">{errors[field.key]}</span>}
          </label>
        ))}
        <div className="criteria-actions">
          <button type="submit">Save</button>
          <button type="button" className="secondary" onClick={() => window.history.back()}>Back</button>
          {message && <span role="status">{message}</span>}
        </div>
      </form>
    </section>
  )
}
