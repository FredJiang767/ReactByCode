import { createMainPage } from './MainShell'
import { StandalonePage } from './PageDocument'

// Route of CustomerController.ListPage.
export const customerListRoute = createMainPage({
  path: '/Customers',
  title: 'Customers',
  component: StandalonePage,
})