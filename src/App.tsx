import React from 'react';
import logo from './logo.svg';
import './App.css';
import 'bootstrap/dist/css/bootstrap.min.css';
import { PatientSearch } from './PatientSearch';

function App() {
  return (
    <div className="App">
      <header className="bg-dark text-white text-center py-3">
        <h1>Your Hospital's Patient Database</h1>
      </header>
      <main className="container my-5">
        <PatientSearch />
      </main>
      <footer className="bg-dark text-white text-center py-3">
        &copy; {(new Date()).getFullYear()} Your Hospital Name
      </footer>
    </div>
  );
}

export default App;
