export default function ListofPlayers({ players }) {
return (
    <ul>
    {players.map((item, index) => (
        <li key={index}>Mr. {item.name} <span>Score: {item.score}</span></li>
    ))}
    </ul>
);
}
