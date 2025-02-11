class EmployeesManager:
    def __init__(self):
        self.employees = []

    def addEmployee(self, employee):
        self.employees.append(employee)

    def displayAllEmployees(self):
        if not self.employees:
            print("Brak pracowników do wyświetlenia.")
        else:
            for emp in self.employees:
                print(emp)

    def removeEmployeesInAgeRange(self, min_age, max_age):
        self.employees = [emp for emp in self.employees if not (min_age <= emp.age <= max_age)]
        print(f"Usunięto pracowników w przedziale wiekowym od {min_age} do {max_age}.")

    def findEmployeeByName(self, name):
        found = [emp for emp in self.employees if emp.name.lower() == name.lower()]
        if found:
            for emp in found:
                print(emp)
        else:
            print(f"Brak pracownika o nazwisku {name}.")

    def updateEmployeeSalary(self, name, new_salary):
        found = [emp for emp in self.employees if emp.name.lower() == name.lower()]
        if found:
            for emp in found:
                emp.update_salary(new_salary)
            print(f"Wynagrodzenie pracownika {name} zostało zaktualizowane na {new_salary} PLN.")
        else:
            print(f"Brak pracownika o nazwisku {name}.")
