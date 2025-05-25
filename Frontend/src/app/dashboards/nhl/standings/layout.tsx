import styles from './styles.module.css';
import { Black_Ops_One } from 'next/font/google';
// import { useTitle } from "@/contexts/TitleContext";

const blackOpsOne = Black_Ops_One({
    subsets: ['latin'],
    weight: '400',
});

export default function NhlLayout({
    children,
}: {
    children: React.ReactNode;
}) {
    // TODO: use the TitleContext to set the page title dynamically
    // const { pageTitle } = useTitle()
    return (
        <html className={`${styles.background} ${blackOpsOne.className}`} lang="en">
            <head>
                {/* <title>{pageTitle}</title> */}
                <title>Dashboards</title>
            </head>
            <body className={styles.body}>
                {children}
            </body>
        </html>
    );
}