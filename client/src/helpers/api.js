import axios from 'axios'

const backEnd = "http://localhost:3000/tasks/"

export const ViewAllTasks = async () => {
   try {
      let response = await axios.get(backEnd)
      return response.data
   } catch (err) {
      console.error(err)
   }
}

export const AddNewTask = async (word) => {
   try {
      let response = await axios.post(backEnd, word)
      return response.data
   } catch (err) {
      console.error(err)
   }
}

export const UpdateTask = async (id, word) => {
   try {
      let response = await axios.put(backEnd + id, word)
      return response.data
   } catch (err) {
      console.error(err)
   }
}

export const ViewTaskById = async (id) => {
   try {
      let response = await axios.get(backEnd + id)
      return response.data
   } catch (err) {
      console.error(err)
   }
}

export const DeleteAllTasks = async () => {
   try {
      let response = await axios.delete(backEnd)
      return response.data
   } catch (err) {
      console.error(err)
   }
}

export const DeleteTask = async (id) => {
   try {
      let response = await axios.delete(backEnd + id)
      return response.data
   } catch (err) {
      console.error(err)
   }
}