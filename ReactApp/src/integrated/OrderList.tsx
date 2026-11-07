import { createMainPage } from './MainShell'
import { StandalonePage } from './PageDocument'

// Route of OrderController.ListPage.
export const orderListRoute = createMainPage({
  path: '/Orders',
  title: 'Orders',
  component: StandalonePage,
})