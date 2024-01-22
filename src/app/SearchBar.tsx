// SearchBar.tsx
import React, { useState } from 'react';
import { Button, Form, FormControl, Row, Col } from 'react-bootstrap';

interface SearchBarProps {
    onSearch: (name: string) => void;
}

export const SearchBar: React.FC<SearchBarProps> = ({ onSearch }) => {
    const [name, setName] = useState('');

    const handleSubmit = (event: React.FormEvent<HTMLFormElement>) => {
        event.preventDefault();
        onSearch(name);
    };

    return (
        <Form onSubmit={handleSubmit}>
            <Row className="gx-2" noGutters>
                <Col>
                    <FormControl
                        type="text"
                        placeholder="Search"
                        className="mb-2"
                        value={name}
                        onChange={(e) => setName(e.target.value)}
                    />
                </Col>
                <Col xs="auto">
                    <Button type="submit" variant="primary" className="mb-2 w-100">
                        Search
                    </Button>
                </Col>
            </Row>
        </Form>
    );
};
