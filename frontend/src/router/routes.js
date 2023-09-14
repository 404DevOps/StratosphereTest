import LeaderBoard from '../components/LeaderBoard.vue'
import Activity from '../components/ActivitiesList.vue'
import Test from '../components/TestPage.vue'
import PlayerDetails from '../components/PlayerDetails.vue'

const routes = [
    { path: '/leaderboard', component: LeaderBoard },
    { path: '/activity', component: Activity },
    { path: '/details/:playerId', component: PlayerDetails },
    { path: '/test', component: Test }
]

export default routes