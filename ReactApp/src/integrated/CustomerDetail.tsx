import { createMainPage } from './MainShell'
import { StandalonePage } from './PageDocument'

export const customerDetailRoute = createMainPage({
  path: '/Customers/Detail',
  title: 'Customer Detail',
  inNavigation: false,
  component: StandalonePage,
})
