import './Edit.scss';

import Button from '@mui/material/Button';

const New = ({ inputs, title }) => {
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
                                {inputs.map((input) => (
                                    <div className="formInput" key={input.id}>
                                        <label>{input.label}</label>
                                        <input type={input.type} placeholder={input.placeholder} />
                                    </div>
                                ))}

                                <Button
                                    className="btn"
                                    style={{ margin: '10px', marginLeft: '70px' }}
                                    type="submit"
                                    variant="outlined"
                                    color="success"
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
};

export default New;
