<b>.Net Core Web Api with Docker</b><br>
api.livriaria.auth WebApi self contained in a Docker container.
<hr>
<b>How to build it:</b>
<hr>
1 - Open PowerShell or CMD and navigate to the api.livraria.auth folder.<br>

2 - Run both commmands:

docker build -t {your-tag} .

docker run -d -p 8080:80 --name myapp {your-tag}

How to test it:
Open your browser at: http://localhost:8080/
