import { useQuery } from '@tanstack/react-query'
import type { CriteriaValues, PageSection, TableData } from './PageConfiguration'
import { getJson } from '@/api/request'
import { formatCell } from './format'

// Renders one table section: columns come from the server definition, rows from its source URL.
// params are sent as query string values (the search criteria of a search section).
export function PageTable({ section, params = {} }: { section: PageSection; params?: CriteriaValues }) {
  const { table } = section
  const query = useQuery({
    queryKey: ['table', section.key, params],
    queryFn: () => {
      const search = new URLSearchParams(params).toString()
      return getJson<TableData>(search ? section.source + '?' + search : section.source)
    },
  })
  const items = query.data?.items ?? []

  return (
    <section className="card">
      <h2>{table.title}</h2>
      {query.isLoading && <p role="status">Loading...</p>}
      {query.isError && <p role="alert">{query.error.message}</p>}
      {query.isSuccess && items.length === 0 && <p>{table.emptyMessage}</p>}
      {items.length > 0 && (
        <table>
          <thead>
            <tr>{table.columns.map((c) => <th key={c.key} className={c.format === 'currency' ? 'num' : undefined}>{c.title}</th>)}</tr>
          </thead>
          <tbody>
            {items.map((row) => (
              <tr key={String(row[table.rowKey])}>
                {table.columns.map((c) => <td key={c.key} className={c.format === 'currency' ? 'num' : undefined}>{formatCell(row[c.key], c.format)}</td>)}
              </tr>
            ))}
          </tbody>
        </table>
      )}
    </section>
  )
}