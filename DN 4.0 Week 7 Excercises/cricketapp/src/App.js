import { useState } from 'react';
import EvenPlayers from './components/EvenPlayers';
import { IndianPlayers } from './components/IndianPlayers';
import ListOfIndianPlayers from './components/ListOfIndianPlayers';
import ListOfPlayers from './components/ListofPlayers';
import OddPlayers from './components/OddPlayers';
import ScoreBelow70 from './components/ScoreBelow70';

function App() {
  const [flag, setFlag] = useState(true);

  const players = [
    { name: 'Virat', score: 85 },
    { name: 'Rohit', score: 45 },
    { name: 'Dhoni', score: 65 },
    { name: 'Hardik', score: 95 },
    { name: 'Shami', score: 60 },
    { name: 'Ashwin', score: 72 },
    { name: 'Gill', score: 39 },
    { name: 'Surya', score: 50 },
    { name: 'Jadeja', score: 82 },
    { name: 'Bumrah', score: 78 },
    { name: 'Ishan', score: 58 },
  ];

  return (
    <div>
      <button onClick={() => setFlag(!flag)}>
        Toggle View (Current: {flag ? 'Players List' : 'Indian Team'})
      </button>

      <hr />

      {flag ? (
        <div>
          <h1>List of Players</h1>
          <ListOfPlayers players={players} />

          <hr />

          <h1>List of Players having Scores Less than 70</h1>
          <ScoreBelow70 players={players} />
        </div>
      ) : (
        <div>
          <h1>Indian Team</h1>

          <h2>Odd Players</h2>
          <OddPlayers players={IndianPlayers} />

          <h2>Even Players</h2>
          <EvenPlayers players={IndianPlayers} />

          <h2>List of Indian Players Merged:</h2>
          <ListOfIndianPlayers players={IndianPlayers} />
        </div>
      )}
    </div>
  );
}

export default App;
