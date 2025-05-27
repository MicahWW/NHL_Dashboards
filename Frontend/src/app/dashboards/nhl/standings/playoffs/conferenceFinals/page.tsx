import { fetchPlayoffs } from '../fetchPlayoffs';
import ConferenceFinals from './ConferenceFinals';
import './styles.css';

export default async function Page() {
    const [, , roundThreeFetch] = await fetchPlayoffs();

    return (
        <ConferenceFinals roundThree={roundThreeFetch}/>
    );
}