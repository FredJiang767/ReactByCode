import { fileURLToPath, URL } from 'node:url'
import { defineConfig } from 'vite'
import react from '@vitejs/plugin-react'

const backend = 'http://localhost:12092'

export default defineConfig({
  plugins: [react({ exclude: [/node_modules/, '**/src/integrated/main.tsx'] })],
  base: './',
  appType: 'custom',
  resolve: { alias: { '@': fileURLToPath(new URL('./src', import.meta.url)) } },
  server: {
    host: 'localhost',
    port: 5173,
    strictPort: true,
    cors: true,
    hmr: { path: '/__vite_hmr' },
    proxy: { '^/(api|Customers)': { target: backend, changeOrigin: true } },
  },
  build: {
    manifest: true,
    rolldownOptions: {
      input: { main: fileURLToPath(new URL('./src/integrated/main.tsx', import.meta.url)) },
    },
  },
})