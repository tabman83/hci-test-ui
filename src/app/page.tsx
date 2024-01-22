"use client"
import React, { useState } from 'react';
import { Container, Row, Col } from 'react-bootstrap';
import { SearchBar } from './SearchBar';
import { PatientInfo } from './PatientInfo';
import { VisitsList } from './VisitsList';
import axios from 'axios';
import './page.css'; // Import your custom CSS

interface Patient {
    id: string;
    name: string;
    age: number;
}

interface Visit {
    consultantName: string;
    appointment: Date;
}

const Page: React.FC = () => {
  const [patient, setPatient] = useState<Patient | null>(null);
  const [visits, setVisits] = useState<Visit[]>([]);
  const [message, setMessage] = useState('');
  const [searchPerformed, setSearchPerformed] = useState(false);
  const [visitSearchPerformed, setVisitSearchPerformed] = useState(false);

  const handleSearch = async (name: string) => {
      setSearchPerformed(true);
      setVisitSearchPerformed(false); // Reset visit search status when a new patient search is performed
      try {
          const response = await axios.get(`api/patients/find/${name}`);
          setPatient(response.data);
          setMessage('');
      } catch (error) {
          setPatient(null);
          if (axios.isAxiosError(error) && error.response && error.response.status === 404) {
              setMessage('Patient not found.');
          } else {
              setMessage('An error occurred.');
          }
      }
  };

  const handleGetVisits = async (patientId: string) => {
      setVisitSearchPerformed(true);
      try {
          const response = await axios.get(`api/patients/${patientId}/visits`);
          setVisits(response.data);
          if (response.data.length === 0) {
              setMessage('No visits found for this patient.');
          } else {
              setMessage('');
          }
      } catch (error) {
          setMessage('Error fetching visits.');
      }
  };

    return (
      <Container className="app-container">
          <Row className="justify-content-md-center">
              <Col md="6">
                  <h1 className="text-center">Patient Lookup</h1>
                  <p className="text-center description">
                      Enter a patient&apos;s first or last name to search for their records.
                  </p>
                  <SearchBar onSearch={handleSearch} />
                  {searchPerformed && !patient && <p className="text-center">{message}</p>}
                  {patient && <PatientInfo name={patient.name} id={patient.id} age={patient.age} onGetVisits={handleGetVisits} />}
                  {visitSearchPerformed && visits.length === 0 && <p className="text-center">{message}</p>}
                  {visits.length > 0 && <VisitsList visits={visits} />}
              </Col>
          </Row>
      </Container>
  );
};

export default Page;