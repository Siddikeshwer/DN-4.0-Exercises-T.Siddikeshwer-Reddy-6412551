function BlogDetails({ blogs }) {
  return (
    <div>
      <h2>Blog Details</h2>
      {blogs.map((b, index) => (
        <div key={index}>
          <h3>{b.title}</h3>
          <strong>{b.author}</strong>
          <p>{b.content}</p>
        </div>
      ))}
    </div>
  );
}

export default BlogDetails;
