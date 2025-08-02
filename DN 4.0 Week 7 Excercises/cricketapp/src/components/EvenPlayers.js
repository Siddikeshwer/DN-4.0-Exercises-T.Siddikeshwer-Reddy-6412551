export default function EvenPlayers({ players }) {
  const [, second, , fourth, , sixth] = players;

  return (
    <ul>
      <li>Second: {second}</li>
      <li>Fourth: {fourth}</li>
      <li>Sixth: {sixth}</li>
    </ul>
  );
}
