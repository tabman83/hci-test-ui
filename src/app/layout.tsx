import type { Metadata } from 'next'
import 'bootstrap/dist/css/bootstrap.min.css';


export const metadata: Metadata = {
  title: 'Hospital Information System'
}

export default function RootLayout({
  children,
}: {
  children: React.ReactNode
}) {
  return (
    <html lang="en">
      <body>{children}</body>
    </html>
  )
}
