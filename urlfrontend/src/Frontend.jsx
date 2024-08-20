import axios from 'axios'
import { useState } from 'react'

const Frontend = () => {
    const api = 'https://localhost:7136/shorten' // The endpoint to shorten the URL
    const [shortUrl, setShortUrl] = useState("")
    const [error, setError] = useState(null)

    const handleShortenUrl = async () => {
        const url = document.getElementById("url").value
        if (!url) {
            setError("Please enter a URL")
            return
        }

        try {
            const response = await axios.post(api, { url })
            setShortUrl(response.data)
            setError(null)
        } catch (err) {
            setError("Failed to shorten URL")
        }
    }

    const handleClipboard = () => {
        if (shortUrl) {
            navigator.clipboard.writeText(shortUrl)
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
                                <button className="ui primary button" onClick={handleShortenUrl}>
                                    Enter
                                </button>
                            </th>
                        </tr>
                    </thead>
                    <br />
                    {error && <div style={{ color: 'red' }}>{error}</div>}
                    <tbody>
                        <tr>
                            <th>
                                <input
                                    type="text"
                                    id="shorturl"
                                    name="shorturl"
                                    placeholder="New Shortened Url"
                                    value={shortUrl}
                                    readOnly
                                />
                            </th>
                            <th>
                                <button id="clipboard" onClick={handleClipboard}>
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

