import './App.css';

function App() {
  const element = "Office Space";
  const sr = "https://officebanao.com/wp-content/uploads/2024/06/office-with-lot-desks-computers-799x799.jpg";
  const ItemName = {
    Name: "DBS",
    Rent: 70000,
    Address: "Chennai"
  };

  const colors = [];
  if (ItemName.Rent <= 60000) {
    colors.push('textRed');
  } else {
    colors.push('textGreen');
  }

  const jsxatt = <img src={sr} width="25%" height="25%" alt="Office Space" />;

  return (
    <div className="App">
      <h1>{element}, at Affordable Range</h1>
      {jsxatt}
      <h2>Name: {ItemName.Name}</h2>
      <h3 className={colors.join(' ')}>Rent: Rs. {ItemName.Rent}</h3>
      <h3>Address: {ItemName.Address}</h3>
    </div>
  );
}

export default App;
