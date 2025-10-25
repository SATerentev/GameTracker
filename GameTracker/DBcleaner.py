import sqlite3

db_file = "GameTracker.db"
connection = sqlite3.connect(db_file)
cursor = connection.cursor()

cursor.execute('''
    DELETE FROM Users
    WHERE (Status = 1 AND RegistrationDate < DATE('now', '-14 days'))
    OR (Status = 3 AND DeleteDate < Date('now', '-6 months'))
''')

connection.commit()
connection.close()