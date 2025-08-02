function BookDetails({ books }) {
  return (
    <div>
      <h2>Book Details</h2>
      {books.map((b) => (
        <div key={b.id}>
          <h3>{b.bname}</h3>
          <p>{b.price}</p>
        </div>
      ))}
    </div>
  );
}

export default BookDetails;
