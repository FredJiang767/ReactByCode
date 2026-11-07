export interface TableColumn {
  key: string
  title: string
  format: 'none' | 'date' | 'datetime' | 'currency' | 'link'
  href: string | null
}

export interface HeaderLink {
  label: string
  href: string
}

export interface TableMetadata {
  title: string
  rowKey: string
  emptyMessage: string
  columns: TableColumn[]
  headerLinks: HeaderLink[]
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

export interface FormField {
  key: string
  label: string
  type: 'text'
  required: boolean
}

export interface FormMetadata {
  fields: FormField[]
}

export type FormValues = Record<string, string | number | null>

export interface SaveResult {
  id: number | null
  errors: Record<string, string>
}

export interface PageSection {
  key: string
  type: 'table' | 'search' | 'form'
  criteria: CriteriaMetadata | null
  form: FormMetadata | null
  table: TableMetadata
  source: string
  saveSource: string | null
}

export interface PageConfiguration {
  schemaVersion: number
  sections: PageSection[]
}

export interface TableData {
  items: Record<string, unknown>[]
}
