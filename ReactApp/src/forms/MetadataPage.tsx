import { useQuery } from '@tanstack/react-query'
import type { PageConfiguration, PageSection } from './PageConfiguration'
import { getJson } from '@/api/request'
import { PageTable } from './PageTable'
import { SearchSection } from './SearchSection'

// Picks the component for a section by its declared type.
function Section({ section }: { section: PageSection }) {
  return section.type === 'search' ? <SearchSection section={section} /> : <PageTable section={section} />
}

// Loads the page definition from the server and renders each of its sections.
export function MetadataPage({ configurationUrl }: { configurationUrl: string }) {
  const query = useQuery({
    queryKey: ['page', configurationUrl],
    queryFn: () => getJson<PageConfiguration>(configurationUrl),
  })
  if (query.isLoading) return <p role="status">Loading...</p>
  if (query.isError) return <p role="alert">{query.error.message}</p>
  return (
    <main>
      {query.data!.sections.map((section) => <Section key={section.key} section={section} />)}
    </main>
  )
}