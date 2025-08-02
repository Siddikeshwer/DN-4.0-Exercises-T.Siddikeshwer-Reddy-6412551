import { useState } from 'react';

function App() {
  const [count, setCount] = useState(0);
  const [result, setResult] = useState('');
  const [rupees, setRupees] = useState('');

  const handleIncrement = () => {
    setCount(count + 1);
    sayHello(); // Trigger another function
  };

  const handleDecrement = () => {
    setCount(count - 1);
  };

  const sayHello = () => {
    alert("Hello! You clicked Increase!");
  };

  const sayWelcome = (message) => {
    alert(`Welcome! Message: ${message}`);
  };

  const handleClick = (e) => {
    alert("I was clicked using Synthetic Event!");
  };

  const handleConvert = (e) => {
    e.preventDefault();
    const euro = (parseFloat(rupees) / 90).toFixed(2);
    setResult(`€${euro}`);
  };

  return (
    <div style={{ padding: '30px' }}>
      <h1>React Events Example</h1>

      <h2>Counter: {count}</h2>
      <button onClick={handleIncrement}>Increase</button>
      <button onClick={handleDecrement}>Decrease</button>

      <br /><br />
      <button onClick={() => sayWelcome("Welcome to React Events!")}>Say Welcome</button>

      <br /><br />
      <button onClick={handleClick}>Synthetic Event Button</button>

      <br /><br />
      <h3>Currency Converter (INR ➝ EURO)</h3>
      <form onSubmit={handleConvert}>
        <input
          type="text"
          placeholder="Enter amount in ₹"
          value={rupees}
          onChange={(e) => setRupees(e.target.value)}
        />
        <button type="submit">Convert</button>
      </form>
      <h4>Result: {result}</h4>
    </div>
  );
}

export default App;
