import { createRootRoute, createRoute, Link, Outlet } from '@tanstack/react-router'

interface MainPage {
  path: string
  title: string
}

// Every page created through createMainPage; the navigation bar lists them.
const mainPages: MainPage[] = []

function MainShell() {
  return (
    <>
      <nav className="nav">
        {mainPages.map((page) => (
          // Each page has its own server-rendered shell and configuration, so navigation reloads the document.
          <Link key={page.path} to={page.path} reloadDocument activeProps={{ className: 'active' }}>{page.title}</Link>
        ))}
      </nav>
      <Outlet />
    </>
  )
}

export const mainRoute = createRootRoute({ component: MainShell })

// Declares one browser route. The path must equal the page URL served by its controller.
export function createMainPage({ path, title, component }: MainPage & { component: () => React.JSX.Element }) {
  mainPages.push({ path, title })
  return createRoute({ getParentRoute: () => mainRoute, path, component })
}