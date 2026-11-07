import { useQuery } from '@tanstack/react-query'
import type { PageConfiguration, PageSection } from './PageConfiguration'
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
    queryFn: async () => {
      const response = await fetch(configurationUrl, { headers: { Accept: 'application/json' } })
      if (!response.ok) throw new Error('Request failed: ' + response.status)
      return response.json() as Promise<PageConfiguration>
    },
  })
  if (query.isLoading) return <p role="status">Loading...</p>
  if (query.isError) return <p role="alert">{query.error.message}</p>
  return (
    <main>
      {query.data!.sections.map((section) => <Section key={section.key} section={section} />)}
    </main>
  )
}