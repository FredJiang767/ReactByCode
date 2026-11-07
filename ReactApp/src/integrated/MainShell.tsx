import { createRootRoute, createRoute, Link, Outlet } from '@tanstack/react-router'

interface MainPage {
  path: string
  title: string
  inNavigation?: boolean
}

const mainPages: MainPage[] = []

function MainShell() {
  return (
    <>
      <nav className="nav">
        {mainPages.filter((page) => page.inNavigation !== false).map((page) => (
          <Link key={page.path} to={page.path} reloadDocument activeProps={{ className: 'active' }}>{page.title}</Link>
        ))}
      </nav>
      <Outlet />
    </>
  )
}

export const mainRoute = createRootRoute({ component: MainShell })

export function createMainPage({ path, title, inNavigation, component }: MainPage & { component: () => React.JSX.Element }) {
  mainPages.push({ path, title, inNavigation })
  return createRoute({ getParentRoute: () => mainRoute, path, component })
}
