// Mirrors the JSON produced by the server's PageMetadata (see Common/Forms/PageConfiguration.cs).
export interface TableColumn {
  key: string
  title: string
  format: 'none' | 'date' | 'datetime' | 'currency'
}

export interface TableMetadata {
  title: string
  rowKey: string
  emptyMessage: string
  columns: TableColumn[]
}

export interface CriteriaOption {
  value: string
  label: string
}

export interface CriteriaField {
  key: string
  label: string
  type: 'text' | 'date' | 'select'
  options: CriteriaOption[] | null
}

export interface CriteriaMetadata {
  fields: CriteriaField[]
}

export type CriteriaValues = Record<string, string>

export interface PageSection {
  key: string
  type: 'table' | 'search'
  criteria: CriteriaMetadata | null
  table: TableMetadata
  source: string
}

export interface PageConfiguration {
  schemaVersion: number
  sections: PageSection[]
}

export interface TableData {
  items: Record<string, unknown>[]
}