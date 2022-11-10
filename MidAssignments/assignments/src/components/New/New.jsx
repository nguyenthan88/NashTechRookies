import './New.scss';
import Button from '@mui/material/Button';
// import { useEffect, useState } from 'react';
// import axios from 'axios';

function New({ title }) {
    // const [categories, setCategories] = useState([]);

    // const [categoryname, setCategoryName] = useState([]);
    // const [description, setDescription] = useState([]);
    // const [addResult, setAddResult] = useState(false);

    // const addCategory = async () => {
    //     if (categoryname != null) {
    //         try {
    //             const response = await fetch(`https://localhost:7233/Category`, {
    //                 method: 'POST',
    //                 body: JSON.stringify({
    //                     Name: categoryname,
    //                     description: description,
    //                 }),
    //                 headers: {
    //                     Accept: 'application/json',
    //                     'Content-Type': 'application/json',
    //                     'Access-Control-Allow-Origin': '*',
    //                 },
    //             });

    //             const data = response.json();

    //             if (data != null) {
    //                 setAddResult((pre) => !pre);
    //             }
    //         } catch (error) {
    //             console.log('error');
    //         }
    //     }

    //     return null;
    // };

    // useEffect(() => {
    //     axios
    //         .get(`https://localhost:7233/Category`)
    //         .then((categories) => {
    //             console.log(categories.data);
    //             setCategories(categories.data);
    //         })

    //         .catch(() => {
    //             console.log('error');
    //         });
    // }, [addResult]);

    return (
        <div className="news">
            <div className="new">
                <div className="newContainer">
                    <div className="top">
                        <h1>{title}</h1>
                    </div>
                    <div className="bottom">
                        <div className="right">
                            <form>
                                <div className="formInput">
                                    <label>Category Name</label>
                                    <input
                                    // onChange={(e) => setCategoryName(e.target.value)}
                                    />
                                    <label>Description</label>
                                    <input
                                    // onChange={(e) => setCategoryName(e.target.value)}
                                    />
                                </div>

                                <Button
                                    className="btn"
                                    style={{ margin: '10px', marginLeft: '70px' }}
                                    type="submit"
                                    variant="outlined"
                                    color="success"
                                    // onClick={addCategory}
                                >
                                    Submit
                                </Button>
                            </form>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    );
}

export default New;
