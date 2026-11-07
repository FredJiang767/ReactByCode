import { useQuery } from '@tanstack/react-query'
import type { PageConfiguration } from './PageConfiguration'
import { PageTable } from './PageTable'

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
      {query.data!.sections.map((section) => <PageTable key={section.key} section={section} />)}
    </main>
  )
}