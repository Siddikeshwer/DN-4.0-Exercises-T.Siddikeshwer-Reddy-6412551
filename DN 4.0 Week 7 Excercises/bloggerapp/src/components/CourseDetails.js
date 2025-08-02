function CourseDetails({ courses }) {
  return (
    <div>
      <h2>Course Details</h2>
      {courses.map((c, index) => (
        <div key={index}>
          <h3>{c.name}</h3>
          <p>{c.date}</p>
        </div>
      ))}
    </div>
  );
}

export default CourseDetails;
