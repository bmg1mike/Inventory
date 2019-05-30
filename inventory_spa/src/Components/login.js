import React from 'react'

const Login = ()=> {
  return (
    <div>
        <div className="container">
            <div className="row">
                <div className="col-md-4 mx-auto">
                    <div className="card mt-5">
                        <div className="card-header bg-danger">
                            <img src="https://rhbooks.com.ng/wp-content/uploads/2018/03/new-roving-heights-books-logoWHITE.png" alt="Rovingheights Logo"/>
                        </div>
                        <div className="card-body">

                            <form method="post">

                                <div className="form-group">
                                    <input type="email" placeholder="Your Email" className="form-control"/>
                                </div>

                                <div className="form-group">
                                    <input type="password" placeholder="Your Password" className="form-control"/>
                                </div>

                                <div>
                                    <input type="submit" className="btn btn-lg btn-block btn-danger" value="Log In"/>
                                </div>

                            </form>
                        </div>
                    </div>

                </div>
            </div>
        </div>
    </div>
  )
}

export default Login

