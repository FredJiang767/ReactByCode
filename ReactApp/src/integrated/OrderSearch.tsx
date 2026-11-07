import { createMainPage } from './MainShell'
import { StandalonePage } from './PageDocument'

// Route of OrderController.SearchPage.
export const orderSearchRoute = createMainPage({
  path: '/OrderSearch',
  title: 'Order Search',
  component: StandalonePage,
})