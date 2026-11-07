import { useQuery } from '@tanstack/react-query'
import type { CriteriaValues, PageSection, TableColumn, TableData } from './PageConfiguration'
import { getJson } from '@/api/request'
import { formatCell } from './format'

type Row = Record<string, unknown>

function rowHref(template: string, row: Row) {
  return template.replace(/\{(\w+)\}/g, (_, key: string) => encodeURIComponent(String(row[key] ?? '')))
}

function Cell({ column, row }: { column: TableColumn; row: Row }) {
  const text = formatCell(row[column.key], column.format)
  return (
    <td className={column.format === 'currency' ? 'num' : undefined}>
      {column.format === 'link' && column.href ? <a href={rowHref(column.href, row)}>{text}</a> : text}
    </td>
  )
}

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
      <div className="card-header">
        <h2>{table.title}</h2>
        {table.headerLinks.map((link) => <a key={link.href} className="button" href={link.href}>{link.label}</a>)}
      </div>
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
                {table.columns.map((c) => <Cell key={c.key} column={c} row={row} />)}
              </tr>
            ))}
          </tbody>
        </table>
      )}
    </section>
  )
}
