import type { TableColumn } from './PageConfiguration'

export function formatCell(value: unknown, format: TableColumn['format']): string {
  if (value === null || value === undefined || value === '') return ''
  if (format === 'currency') return Number(value).toLocaleString(undefined, { style: 'currency', currency: 'USD' })
  if (format === 'date') return new Date(String(value)).toLocaleDateString()
  if (format === 'datetime') return new Date(String(value)).toLocaleString()
  return String(value)
}