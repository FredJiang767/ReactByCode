import { useState, type SubmitEvent } from 'react'
import type { CriteriaMetadata, CriteriaValues } from './PageConfiguration'

// Renders the server-declared criteria fields. Search sends only the fields the user filled in.
export function SearchCriteriaForm({ criteria, onSearch }: { criteria: CriteriaMetadata; onSearch: (values: CriteriaValues) => void }) {
  const [values, setValues] = useState<CriteriaValues>({})

  function submit(event: SubmitEvent<HTMLFormElement>) {
    event.preventDefault()
    onSearch(Object.fromEntries(Object.entries(values).filter(([, value]) => value !== '')))
  }

  function reset() {
    setValues({})
    onSearch({})
  }

  return (
    <form className="criteria" onSubmit={submit}>
      {criteria.fields.map((field) => (
        <label key={field.key}>
          <span>{field.label}</span>
          {field.type === 'select' ? (
            <select value={values[field.key] ?? ''} onChange={(e) => setValues({ ...values, [field.key]: e.target.value })}>
              <option value="">All</option>
              {field.options?.map((option) => <option key={option.value} value={option.value}>{option.label}</option>)}
            </select>
          ) : (
            <input type={field.type} value={values[field.key] ?? ''} onChange={(e) => setValues({ ...values, [field.key]: e.target.value })} />
          )}
        </label>
      ))}
      <div className="criteria-actions">
        <button type="submit">Search</button>
        <button type="button" className="secondary" onClick={reset}>Reset</button>
      </div>
    </form>
  )
}