import { useState } from 'react';
import BlogDetails from './components/BlogDetails';
import BookDetails from './components/BookDetails';
import CourseDetails from './components/CourseDetails';
import './App.css'; // Import CSS

function App() {
  const [showAll, setShowAll] = useState(true);

  const books = [
    { id: 101, bname: 'Master React', price: 670 },
    { id: 102, bname: 'Deep Dive Into Angular 11', price: 800 },
    { id: 103, bname: 'Mongo Essentials', price: 450 },
  ];

  const blogs = [
    {
      title: 'React Learning',
      author: 'Stephen Biz',
      content: 'Welcome to learning React!',
    },
    {
      title: 'Installation',
      author: 'Schewzdenier',
      content: 'You can install React from npm.',
    },
  ];

  const courses = [
    { name: 'Angular', date: '4/5/2021' },
    { name: 'React', date: '6/3/2021' },
  ];

  return (
    <div className="container">
      <h1>Blogger App</h1>
      <button onClick={() => setShowAll(!showAll)}>
        {showAll ? 'Show Only Books' : 'Show All Sections'}
      </button>

      <div className="flex-container">
        <CourseDetails courses={courses} />
        <BookDetails books={books} />
        {showAll && <BlogDetails blogs={blogs} />}
      </div>
    </div>
  );
}

export default App;
