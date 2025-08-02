import { useState } from 'react';
import { LoginButton, LogoutButton } from './Buttons';
import { GuestGreeting, UserGreeting } from './Greeting';

function App() {
  const [isLoggedIn, setIsLoggedIn] = useState(false);

  const handleLogin = () => setIsLoggedIn(true);
  const handleLogout = () => setIsLoggedIn(false);

  let greeting;
  let button;

  if (isLoggedIn) {
    greeting = <UserGreeting />;
    button = <LogoutButton onClick={handleLogout} />;
  } else {
    greeting = <GuestGreeting />;
    button = <LoginButton onClick={handleLogin} />;
  }

  return (
    <div style={{ padding: '30px' }}>
      <h1>Ticket Booking Application</h1>
      {greeting}
      <br />
      {button}
    </div>
  );
}

export default App;
