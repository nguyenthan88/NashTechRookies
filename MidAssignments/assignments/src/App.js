import * as React from 'react';
import { Routes, Route } from 'react-router-dom';

import Home from './pages/Home/Home';
import Books from './pages/Books/Books';
import Categories from './pages/Category/Categories';

import Navbar from './components/Navbar/Navbar';
import NewCategory from './components/News/NewCategory';
import NewBook from './components/News/NewBook';
import EditCategory from './components/Edits/EditCategory';
import Logout from './pages/LogOut/Logout';
import Signup from './pages/Signup/Signup';
import EditBook from './components/Edits/EditBook';
import ViewBook from './components/ViewDetails/ViewBook';
import ViewCategory from './components/ViewDetails/ViewCategory';

function App() {
    return (
        <div className="App">
            <Navbar />
            <Routes>
                {/* <Route path="/" element={<Navbar />}> */}
                <Route path="/logout" element={<Logout />} />
                <Route path="/signup" element={<Signup />} />
                <Route path="/home" element={<Home />} />
                <Route path="/category" element={<Categories />} />
                <Route path="/category/new" element={<NewCategory title="Add New Category" />} />
                <Route path="/category/editcategory/:categoryId" element={<EditCategory title="Edit Category" />} />
                <Route path="/category/viewcategory/:categoryId" element={<ViewCategory title="Category Details" />} />
                <Route path="/book" element={<Books />} />
                <Route path="/book/new" element={<NewBook title="Add New Book" />} />
                <Route path="/book/editbook/:bookId" element={<EditBook title="Edit Book" />} />
                <Route path="/book/viewbook/:bookId" element={<ViewBook title="Book Details" />} />
            </Routes>
        </div>
    );
}

export default App;
