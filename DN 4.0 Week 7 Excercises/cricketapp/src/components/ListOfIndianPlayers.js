
export default function ListOfIndianPlayers({ players }) {
  if (!players || !Array.isArray(players)) {
    return <p>No Indian players available</p>;
  }

  return (
    <ul>
      {players.map((player, index) => (
        <li key={index}>{player}</li>
      ))}
    </ul>
  );
}
