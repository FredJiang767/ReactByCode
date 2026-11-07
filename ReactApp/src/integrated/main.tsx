import { createRoot } from 'react-dom/client'
import { QueryClient, QueryClientProvider } from '@tanstack/react-query'
import { MetadataPage } from '@/forms/MetadataPage'
import './app.css'

const queryClient = new QueryClient()
const settings = JSON.parse(document.getElementById('react-config')!.textContent!) as { configurationUrl: string }

createRoot(document.getElementById('root')!).render(
  <QueryClientProvider client={queryClient}>
    <MetadataPage configurationUrl={settings.configurationUrl} />
  </QueryClientProvider>,
)