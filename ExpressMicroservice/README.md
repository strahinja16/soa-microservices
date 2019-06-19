# Releaser API

[ ![Codeship Status for alexa026/releaser-api](https://app.codeship.com/projects/0ee28fe0-6751-0136-e4f1-7aa228e0ad41/status?branch=master)](https://app.codeship.com/projects/297617)

To setup database run within docker container:
```bash
npm run db:build
```

this command will run all the migrations and trigger seeding of dev data.

For production environment it is only required to run:
```bash
npm run migrate
```
