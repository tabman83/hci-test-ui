// PatientSearch.tsx
"use client"

import React, { useState } from 'react';
import { PatientTable } from './PatientTable'; // Import the PatientTable component

export const PatientSearch: React.FC = () => {
    const [searchTerm, setSearchTerm] = useState<string>('');
    const [searchResults, setSearchResults] = useState<any[]>([]); // Type as per your data

    const handleSearch = (e: React.FormEvent<HTMLFormElement>) => {
        e.preventDefault();
        // Implement your search logic here
        console.log('Searching for:', searchTerm);
        // Set search results
    };

    return (
        <div className="container mt-5">
            <h1 className="mb-4">Search Patients and Visits</h1>
            <form onSubmit={handleSearch} className="input-group mb-3">
                <input 
                    type="text" 
                    className="form-control" 
                    value={searchTerm} 
                    onChange={(e) => setSearchTerm(e.target.value)} 
                    placeholder="Enter search term..." 
                />
                <div className="input-group-append">
                    <button className="btn btn-outline-secondary" type="submit">Search</button>
                </div>
            </form>
            <PatientTable data={searchResults} />
        </div>
    );
};