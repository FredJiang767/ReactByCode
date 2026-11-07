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

export interface PageSection {
  key: string
  type: string
  table: TableMetadata
  source: string
}

export interface PageConfiguration {
  schemaVersion: number
  title: string
  sections: PageSection[]
}

export interface TableData {
  items: Record<string, unknown>[]
}