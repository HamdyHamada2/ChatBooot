function sendMessage() {
    const input = document.getElementById('userInput').value;
    fetch('/api/chatbot/ask', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({ text: input })
    })
    .then(res => res.json())
    .then(data => {
        document.getElementById('chatBox').innerHTML += '<p><strong>الرد:</strong> ' + data.response + '</p>';
    });
}