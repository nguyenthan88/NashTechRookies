import * as React from 'react';
import { Routes, Route } from 'react-router-dom';

import Home from './pages/Home/Home';
import Books from './pages/Books/Books';
import Categories from './pages/Category/Categories';

import Navbar from './components/Navbar/Navbar';
import New from './components/New/New';
import Edit from './components/Edit/Edit';
import Logout from './pages/LogOut/Logout';
import Signup from './pages/Signup/Signup';

function App() {
    return (
        <div className="App">
            <Navbar />
            <Routes>
                {/* <Route path="/" element={<Navbar />}> */}
                <Route path="/logout" element={<Logout />} />
                <Route path="/signup" element={<Signup />} />
                <Route path="/home" element={<Home />} />
                <Route path="/book" element={<Books />} />
                <Route path="/category" element={<Categories />} />
                <Route path="/category/new" element={<New title="Add New Category" />} />
                <Route path="/book/new" element={<New title="Add New Book" />} />
                <Route path="/category/edit" element={<Edit title="Edit New Category" />} />
                <Route path="/book/edit" element={<Edit title="Edit New Book" />} />
            </Routes>
        </div>
    );
}

export default App;
