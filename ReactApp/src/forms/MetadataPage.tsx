import { useQuery } from '@tanstack/react-query'
import type { PageConfiguration, PageSection } from './PageConfiguration'
import { getJson } from '@/api/request'
import { DetailForm } from './DetailForm'
import { PageTable } from './PageTable'
import { SearchSection } from './SearchSection'

function Section({ section }: { section: PageSection }) {
  if (section.type === 'form') return <DetailForm section={section} />
  if (section.type === 'search') return <SearchSection section={section} />
  return <PageTable section={section} />
}

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
