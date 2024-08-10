//import axios from 'axios'
import { useState, useEffect } from 'react'

const Frontend = () => {
    const api = 'https://localhost:gateway'
    const [laptops, setLaptops] = useState([])
    const [error, setError] = useState(null)

    /*
    useEffect(() => {
        const fetchData = async () => {
            try {
                const { data } = await axios.get(api)
                setLaptops(data)
            } catch (err) {
                setError(err.message)
            }
        }

        fetchData()
    }, [])

    if (error) {
        return <div>Error: {error}</div>
    }
    */

    function ifEmpty() {
        var surl = document.getElementById("shorturl").value
        if (surl != "") {
            navigator.clipboard.writeText(surl.value)
            document.getElementById("clipboard").innerHTML = "Copied to Clipboard!"
        } else {
            document.getElementById("clipboard").innerHTML = "Copy to Clipboard"
        }
    }

    return (
        <div>
            <div className="container">
                <table className="table">
                    <thead>
                        <tr>
                            <th>
                                <input
                                    type="text" id="url" name="url" placeholder="Enter URL">
                                </input>
                            </th>
                            <th>
                                <button className="ui primary button">Enter</button>
                            </th>
                        </tr>
                    </thead>
                    <br></br>
                    <tbody>
                        <tr>
                            <th>
                                <input type="text" id="shorturl" name="shorturl" placeholder="New Shortened Url" readOnly></input>
                            </th>
                            <th>
                                <button id="clipboard" onClick={ifEmpty}>
                                    Copy to Clipboard
                                </button>
                            </th>
                        </tr>
                    </tbody>
                </table>
            </div>
        </div>
    )
}

export default Frontend
