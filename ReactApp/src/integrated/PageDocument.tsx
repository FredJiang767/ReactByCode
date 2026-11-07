import { MetadataPage } from '@/forms/MetadataPage'
import { settings } from './pageSettings'

// A page whose whole content is the server-declared page definition.
export function StandalonePage() {
  return <MetadataPage configurationUrl={settings.configurationUrl} />
}