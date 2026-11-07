import { createRoot } from 'react-dom/client'
import { QueryClient, QueryClientProvider } from '@tanstack/react-query'
import { createRouter, RouterProvider } from '@tanstack/react-router'
import { mainRoute } from './MainShell'
import { mainPageRoutes } from './routes'
import './app.css'

const queryClient = new QueryClient()
const router = createRouter({ routeTree: mainRoute.addChildren(mainPageRoutes) })

createRoot(document.getElementById('root')!).render(
  <QueryClientProvider client={queryClient}>
    <RouterProvider router={router} />
  </QueryClientProvider>,
)