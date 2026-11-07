import { useState } from 'react'
import type { CriteriaValues, PageSection } from './PageConfiguration'
import { PageTable } from './PageTable'
import { SearchCriteriaForm } from './SearchCriteriaForm'

// A search section: the criteria form on top and the result table below. The table reloads on every search.
export function SearchSection({ section }: { section: PageSection }) {
  const [criteria, setCriteria] = useState<CriteriaValues>({})
  return (
    <>
      <section className="card">
        <SearchCriteriaForm criteria={section.criteria!} onSearch={setCriteria} />
      </section>
      <PageTable section={section} params={criteria} />
    </>
  )
}