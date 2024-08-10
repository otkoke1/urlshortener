import { StrictMode } from 'react'
import { createRoot } from 'react-dom/client'
import './index.css'
import Fend from './Frontend.jsx'

createRoot(document.getElementById('root')).render(
  <StrictMode>
    <Fend />
  </StrictMode>,
)
