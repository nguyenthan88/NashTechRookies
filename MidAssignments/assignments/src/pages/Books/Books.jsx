import * as React from 'react';
import moment from 'moment';
import { useEffect, useState } from 'react';
import { Outlet, Link } from 'react-router-dom';
import axios from 'axios';
import './Books.scss';

import { styled, alpha } from '@mui/material/styles';
import Button from '@mui/material/Button';
import SearchIcon from '@mui/icons-material/Search';
import InputBase from '@mui/material/InputBase';
import Table from '@mui/material/Table';
import TableBody from '@mui/material/TableBody';
import TableCell from '@mui/material/TableCell';
import TableContainer from '@mui/material/TableContainer';
import TableHead from '@mui/material/TableHead';
import TableRow from '@mui/material/TableRow';
import Paper from '@mui/material/Paper';
import Dialog from '@mui/material/Dialog';
import DialogActions from '@mui/material/DialogActions';
import DialogContent from '@mui/material/DialogContent';
import DialogContentText from '@mui/material/DialogContentText';
import DialogTitle from '@mui/material/DialogTitle';

const Search = styled('div')(({ theme }) => ({
    position: 'relative',
    height: '40px',
    margin: '10px',
    borderRadius: theme.shape.borderRadius,
    backgroundColor: '#D3D3D3',
    '&:hover': {
        backgroundColor: alpha(theme.palette.common.black, 0.25),
    },
    marginLeft: -10,
    width: '100%',
    [theme.breakpoints.up('sm')]: {
        display: 'flex',
        width: '500px',
    },
}));

const SearchIconWrapper = styled('div')(({ theme }) => ({
    padding: theme.spacing(0, 2),
    height: '100%',
    position: 'absolute',
    pointerEvents: 'none',
    display: 'flex',
    alignItems: 'center',
    justifyContent: 'center',
}));

const StyledInputBase = styled(InputBase)(({ theme }) => ({
    color: 'inherit',
    '& .MuiInputBase-input': {
        padding: theme.spacing(1, 1, 1, 0),
        paddingLeft: `calc(1em + ${theme.spacing(4)})`,
        transition: theme.transitions.create('width'),
        width: '500px',
        [theme.breakpoints.up('sm')]: {
            width: '444px',
            '&:focus': {
                width: '444px',
            },
        },
    },
}));

function Books() {
    const [books, setBook] = useState([]);
    const [search, setSearch] = useState('');
    const [open, setOpen] = useState(false);

    const handleClickOpen = () => {
        setOpen(true);
    };

    const handleClose = () => {
        setOpen(false);
    };

    useEffect(() => {
        axios
            .get(`https://localhost:7233/Book`)
            .then((books) => {
                console.log(books.data);
                setBook(books.data);
            })

            .catch(() => {
                console.log('error');
            });
    }, []);

    return (
        <div className="book">
            <div style={{ height: 1000, width: '100%' }}>
                <div style={{ padding: '10px', display: 'flex' }}>
                    <Search>
                        <SearchIconWrapper>
                            <SearchIcon />
                        </SearchIconWrapper>
                        <StyledInputBase
                            placeholder="Search…"
                            inputProps={{ 'aria-label': 'search' }}
                            onChange={(e) => setSearch(e.target.value)}
                        />
                    </Search>
                </div>
                <Link to="/book/new" className="link" style={{ listStyle: 'none', textDecoration: 'none' }}>
                    <Button
                        style={{ marginTop: '15px', marginBottom: '15px' }}
                        type="submit"
                        variant="outlined"
                        color="success"
                    >
                        Add
                    </Button>
                </Link>
                <TableContainer component={Paper} className="table bottom title">
                    <Table sx={{ minWidth: 650 }} aria-label="simple table">
                        <TableHead>
                            <TableRow>
                                <TableCell className="tableCell">ID</TableCell>
                                <TableCell className="tableCell">Name</TableCell>
                                <TableCell className="tableCell">PublishingYear</TableCell>
                                <TableCell className="tableCell">Description</TableCell>
                                <TableCell className="tableCell">Price</TableCell>
                                <TableCell className="tableCell">Category ID</TableCell>
                                <TableCell className="tableCell">Actions</TableCell>
                            </TableRow>
                        </TableHead>
                        <TableBody>
                            {books.length > 0
                                ? books
                                      .filter((book) => {
                                          return search.toLowerCase() === ''
                                              ? book
                                              : book.bookName.toLowerCase().includes(search);
                                      })
                                      .map((book) => (
                                          <TableRow key={book.bookId}>
                                              <TableCell className="tableCell">{book.bookId}</TableCell>
                                              <TableCell className="tableCell">{book.bookName}</TableCell>
                                              <TableCell className="tableCell">
                                                  {moment(book.publishingYear).format('DD/MM/YYYY')}
                                              </TableCell>
                                              <TableCell className="tableCell">{book.description}</TableCell>
                                              <TableCell className="tableCell">{book.price}</TableCell>
                                              <TableCell
                                                  className="tableCell"
                                                  style={{
                                                      paddingLeft: '50px',
                                                  }}
                                              >
                                                  {book.categoryId}
                                              </TableCell>
                                              <TableCell className="tableCell">
                                                  <Link
                                                      to={`/book/viewbook/${book.bookId}`}
                                                      className="link"
                                                      style={{ listStyle: 'none', textDecoration: 'none' }}
                                                  >
                                                      <Button
                                                          style={{ marginTop: '15px', margin: '15px' }}
                                                          type="submit"
                                                          variant="outlined"
                                                          color="primary"
                                                      >
                                                          Details
                                                      </Button>
                                                  </Link>
                                                  <Link
                                                      to={`/book/editbook/${book.bookId}`}
                                                      className="link"
                                                      style={{ listStyle: 'none', textDecoration: 'none' }}
                                                  >
                                                      <Button
                                                          style={{ marginTop: '15px', margin: '15px' }}
                                                          type="submit"
                                                          variant="outlined"
                                                          color="secondary"
                                                      >
                                                          Edit
                                                      </Button>
                                                  </Link>
                                                  <Button
                                                      onClick={handleClickOpen}
                                                      style={{ marginTop: '15px', margin: '15px' }}
                                                      type="submit"
                                                      variant="outlined"
                                                      color="error"
                                                  >
                                                      Delete
                                                  </Button>
                                              </TableCell>
                                          </TableRow>
                                      ))
                                : null}
                        </TableBody>
                    </Table>
                </TableContainer>
            </div>
            <div>
                <Dialog
                    open={open}
                    onClose={handleClose}
                    aria-labelledby="alert-dialog-title"
                    aria-describedby="alert-dialog-description"
                >
                    <DialogTitle id="alert-dialog-title">{'Are you Delete?'}</DialogTitle>
                    <DialogContent>
                        <DialogContentText id="alert-dialog-description">
                            Let Google help apps determine location. This means sending anonymous location data to
                            Google, even when no apps are running.
                        </DialogContentText>
                    </DialogContent>
                    <DialogActions>
                        <Button onClick={handleClose}>Close</Button>
                        <Button autoFocus color="error">
                            Delete
                        </Button>
                    </DialogActions>
                </Dialog>
            </div>
            <Outlet />
        </div>
    );
}

export default Books;
