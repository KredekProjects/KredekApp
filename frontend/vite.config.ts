import react from '@vitejs/plugin-react';
import { defineConfig } from 'vite';
import viteCommonJs from 'vite-plugin-commonjs';
import viteTsconfigPaths from 'vite-tsconfig-paths';

// https://vitejs.dev/config/
export default defineConfig({
  plugins: [react(), viteCommonJs(), viteTsconfigPaths()],
  optimizeDeps: {
    esbuildOptions: {
      define: {
        global: 'globalThis'
      }
    }
  },
  server: {
    host: '0.0.0.0',
    port: 3000,
    watch: {
      useFsEvents: true
    }
  }
});
